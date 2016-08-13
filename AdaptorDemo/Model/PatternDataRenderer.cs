using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptorDemo.Model
{
    public class PatternDataRenderer
    {
        private readonly IPatternRendererAdaptor _patternrendererAdaptor;

        public PatternDataRenderer(IPatternRendererAdaptor patternrendererAdaptor)
        {
            _patternrendererAdaptor = patternrendererAdaptor;
        }

        public PatternDataRenderer() : this(new PatternRendrerAdaptor())
        {

        }

        public string ListPatterns(IEnumerable<AdaptorDemo.Model.Pattern> patterns)
        {
            return _patternrendererAdaptor.ListPatterns(patterns);
        }
    }

    public interface IPatternRendererAdaptor
    {
        string ListPatterns(IEnumerable<AdaptorDemo.Model.Pattern> patterns);

    }

    class PatternRendrerAdaptor : IPatternRendererAdaptor
    {
        private DataRenderer _datarenderer;

        public string ListPatterns(IEnumerable<AdaptorDemo.Model.Pattern> patterns)
        {
            DataRendererAdaptor dataRendererAdaptor = new DataRendererAdaptor(patterns);
            _datarenderer = new DataRenderer(dataRendererAdaptor);

            StringWriter sw = new StringWriter();
           _datarenderer.Renderer(sw);

            return sw.ToString();
            
        }

        internal class DataRendererAdaptor : IDbDataAdapter
        {
            public IEnumerable<Pattern> _patterns;
            public DataRendererAdaptor(IEnumerable<Pattern> patterns)
            {
                _patterns = patterns;
            }

            public IDbCommand DeleteCommand
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public IDbCommand InsertCommand
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public MissingMappingAction MissingMappingAction
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public MissingSchemaAction MissingSchemaAction
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public IDbCommand SelectCommand
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public ITableMappingCollection TableMappings
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public IDbCommand UpdateCommand
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public int Fill(DataSet myDataSet)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Id", typeof(string)));
                dt.Columns.Add(new DataColumn("Description", typeof(string)));

                foreach (var item in _patterns)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = item.Id;
                    dr[1] = item.Description;
                    dt.Rows.Add(dr);
                }

                myDataSet.Tables.Add(dt);
                myDataSet.AcceptChanges();

                return 1;
            }

            public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
            {
                throw new NotImplementedException();
            }

            public IDataParameter[] GetFillParameters()
            {
                throw new NotImplementedException();
            }

            public int Update(DataSet dataSet)
            {
                throw new NotImplementedException();
            }
        }
    }

}
