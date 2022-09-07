using System.Collections.Generic;

namespace HikingGear.Models
{
  public class CategoryGear
  {       
    public int CategoryGearId { get; set; }
    public int GearId { get; set; }
    public int CategoryId { get; set; }
    public virtual Gear Gear { get; set; }
    public virtual Category Category { get; set; }
    // public virtual ApplicationUser User { get; set; } 
  }
}