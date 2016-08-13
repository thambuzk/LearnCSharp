using System.Data;
using System.IO;

namespace AdaptorDemo.Model
{
    public class DataRenderer
    {
        public readonly IDbDataAdapter _dataAdapter;

        public DataRenderer(IDbDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        public void Renderer(TextWriter writer)
        {
            writer.WriteLine("Rendering Data:");
            var myDataSet = new DataSet();

            _dataAdapter.Fill(myDataSet);

            foreach (DataTable table in myDataSet.Tables)
            {
                foreach (DataColumn columname in table.Columns)
                {
                    writer.Write(columname.ColumnName.PadRight(20));
                }
                writer.WriteLine();

                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        writer.Write(row[i].ToString().PadRight(20));
                    }
                writer.WriteLine();
            }
            }

        }

    }

}
