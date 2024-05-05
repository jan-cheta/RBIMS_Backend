using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace RBIMS_Backend
{
    
    public class SearchMeNigga
    {
        MakeDataTable makeDataTable = new MakeDataTable();

        public DataTable SearchAlgorithm(string searchText, List<Inhabitant> inhabitantList ){

            DataTable oldInhabitantDT = makeDataTable.makeInhabitantDataTable(inhabitantList);
            // DataTable inhabitantDT = new DataTable();

            // inhabitantDT.Columns.Add("Inhabitant ID", typeof(int));
            // inhabitantDT.Columns.Add("First Name", typeof(string));
            // inhabitantDT.Columns.Add("Last Name", typeof(string));
            // inhabitantDT.Columns.Add("Middle Name", typeof(string));
            // inhabitantDT.Columns.Add("Suffix", typeof(string));
            // inhabitantDT.Columns.Add("Occupation", typeof(string));
            // inhabitantDT.Columns.Add("Date Of Birth", typeof(string));
            // inhabitantDT.Columns.Add("Sex", typeof(char));
            // inhabitantDT.Columns.Add("Civil Status", typeof(string));
            // inhabitantDT.Columns.Add("Citizenship", typeof(string));
            // inhabitantDT.Columns.Add("Contact Number", typeof(string));
            // inhabitantDT.Columns.Add("Educational Attainment", typeof(string));
            // inhabitantDT.Columns.Add("Role In Family", typeof(string));
            // inhabitantDT.Columns.Add("Remarks", typeof(string));
            // inhabitantDT.Columns.Add("Family ID", typeof(int));
            // inhabitantDT.Columns.Add("Household ID", typeof(int));
            List<int> validRows = new List<int>();

            for (int i = 0; i < oldInhabitantDT.Rows.Count; i++)
            {
                for (int j = 0; j < oldInhabitantDT.Columns.Count; j++)
                {
                    if (oldInhabitantDT.Rows[i][j] != null & oldInhabitantDT.Rows[i][j].ToString().ToLower().Contains(searchText))
                    {
                        validRows.Add(Convert.ToInt16(oldInhabitantDT.Rows[i][0]));
                        break;
                }
            }

            List<Inhabitant> filteredInhabitants = new List<Inhabitant>();

            foreach(int row in validRows){
                foreach(Inhabitant inhabitant in inhabitantList){
                    if(inhabitant.InhabitantId == row){
                        filteredInhabitants.Add(inhabitant);
                    }
                }
            }

            return makeDataTable.makeInhabitantDataTable(filteredInhabitants);
        }
    }
}    

