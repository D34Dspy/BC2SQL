using bc2sql.explore.Views;
using bc2sql.shared;
using bc2sql.shared.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bc2sql.explore
{
    internal class SetupScraperController
    {
        private SetupScraperModel _model;
        public ExploreController Explorer;
        public SetupScraperController(SetupScraperModel mdl, ExploreController controller) {
            _model = mdl;
            Explorer = controller;
        }

        public void SetDatabase(int index) {
            if (index >= _model.DatabaseConfigs.Count)
                return;
            _model.Database = _model.DatabaseConfigs[index];
        }
        public void SetDatasource(int index)
        {
            if (index >= _model.DataSourceConfigs.Count)
                return;
            _model.DataSource = _model.DataSourceConfigs[index];
            _model.EntityTypeSets = _model.DataSource.Metadata.SelectSetsAndTypes(
                (EntityType type, EntitySet set, string _namespace) => new EntityTypeSetPair
                {
                    Set = set,
                    Type = type,
                }
            ).ToArray();
        }

        public void SetDataset(int index)
        {
            _model.EntityTypeSet = _model.EntityTypeSets[index];
            _model.Keys.Clear();
            _model.Keys.AddRange(_model.EntityTypeSet.Type.SelectKeys((Key k, PropertyRef r, Property p) => p));
            _model.SelectedKeys.Clear();

            ResetMergeParameters();
            BuildDefaultMergeParameters();
        }

        public void ClearRecordedKeys()
        {
            _model.SelectedKeys.Clear();
        }

        public bool RecordKey(int index)
        {
            var k = _model.Keys[index];
            if (_model.SelectedKey == k || _model.SelectedKeys.Contains(k))
                return false;
            _model.SelectedKey = k;
            _model.SelectedKeys.Add(k);
            return true;
        }


        public void ResetMergeParameters()
        {
            _model.MergeConditions.Clear();
            _model.FormFields.Clear();
        }

        public void BuildDefaultMergeParameters()
        {
            var m = _model;
            if (m.UseSystemGUIDInsertUpdate)
            {
                // OData Filter
            }
            else
            {

            }
        }

        public ScraperConfig CreateConfig()
        {
            var c = Explorer.CreateScraper();

            c.Bind(_model.DataSource, _model.Database);

            c.SourceAlias = _model.SourceAlias;
            c.DestinationAlias = _model.DestinationAlias;

            c.Type = _model.EntityTypeSet.Type;
            c.Set = _model.EntityTypeSet.Set;

            c.FormFields = _model.FormFields.ToArray();
            c.MergeConditions = _model.MergeConditions.ToArray();

            c.UseSystemGuidInsertModifyDate = _model.UseSystemGUIDInsertUpdate;
            c.Keys = _model.SelectedKeys.ToArray();

            c.UseWindowing = _model.UseWindowing;
            c.WindowSize = _model.WindowingDatasets;

            c.TableName = _model.TableName;

            Explorer.SaveScraper();
            Explorer.SaveLibrary();

            // TODO relative size

            

            return c;
        }

        public void SetSourceAlias(string alias)
        {
            _model.SourceAlias = alias;
        }

        public void SetDestinationAlias(string alias)
        {
            _model.DestinationAlias = alias;
        }

        public void SetTableName(string alias)
        {
            _model.TableName = alias;
        }

        public void SetName(string value)
        {
            _model.Name = value;
        }

        public void SetDatasets(decimal value)
        {
            _model.WindowingDatasets = (int)value;
        }

        public void SetPercentage(decimal value)
        {
            _model.WindowingPercentage = (float)value;
        }
        public void AssignNameIfNotAssigned(string value)
        {
            if (_model.Name == null || _model.Name == string.Empty)
                SetName(value);
        }
    }
}
