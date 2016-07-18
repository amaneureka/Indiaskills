using System;
using System.Collections.Generic;

namespace IndiaSkills.Controls
{
    /// <summary>
    /// Database Plan Layout Object
    /// </summary>
    public class PlanDetails
    {
        /// <summary>
        /// Layout Plan Rows count
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// Layout Plan Column Count
        /// </summary>
        public int Columns { get; set; }
        /// <summary>
        /// Layout Name -- should be unique identitfier
        /// </summary>
        public string LayoutName { get; set; }
        /// <summary>
        /// Layout seating arrangement -- binary encoded string
        /// </summary>
        public string EncodedString { get; set; }

        // seat no - availability
        public List<Tuple<int, bool>> GetListViewData()
        {
            var res = new List<Tuple<int, bool>>();

            int area = Rows * Columns;
            for (int i = 0; i < EncodedString.Length; i++)
            {
                bool status = EncodedString[i] != '0';
                res.Add(new Tuple<int, bool>(i, status));
            }

            for (int i = EncodedString.Length; i < area; i++)
                res.Add(new Tuple<int, bool>(i, false));

            return res;
        }
    }
}
