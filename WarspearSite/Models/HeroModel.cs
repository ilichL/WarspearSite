namespace WarspearSite.Models
{
    public class HeroModel
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public decimal Bonus { get; set; }
        public string Class { get; set; }
        public string Fraction { get; set; }
        public virtual ICollection<SkillCreateModel> Skills { get; set; }
        public virtual ICollection<StateModel> State { get; set; }
    }
}
