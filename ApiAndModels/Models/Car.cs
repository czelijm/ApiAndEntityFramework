using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAndEntityFramework.Models.Models
{
    public record Car(int Id, string Model, string Produce, int ModelYear, int Hp, decimal PriceAtPremiere) { }
}
