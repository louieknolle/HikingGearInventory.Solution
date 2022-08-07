using System.Collections.Generic;

namespace HikingGear.Models
{
  public class Gear
  {
    public Gear()
    {
      this.JoinEntities = new HashSet<CategoryGear>();
    }

    public int GearId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int PurchaseYear { get; set; }
    public string Description { get; set; }

    public virtual ICollection<CategoryGear> JoinEntities { get;}
  }
}