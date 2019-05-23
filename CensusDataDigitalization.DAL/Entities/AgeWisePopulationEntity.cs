using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusDataDigitalization.DAL.Entities
{
    /// <summary>
    /// Age Wise Graph Plotter Entity
    /// </summary>
    public class AgeWisePopulationEntity
    {
        public int Age { get; set; }

        public int Count{ get; set; }
    }
}
