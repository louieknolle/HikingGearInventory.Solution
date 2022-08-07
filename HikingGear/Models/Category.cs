using System.Collections.Generic;

namespace HikingGear.Models
{
  public class Category
  {
    public Category()
    {
      this.JoinEntities = new HashSet<CategoryGear>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CategoryGear> JoinEntities { get; set; }
  }
}