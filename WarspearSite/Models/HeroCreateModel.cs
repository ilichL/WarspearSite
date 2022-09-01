namespace WarspearSite.Models
{
    public class HeroCreateModel
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public decimal Bonus { get; set; }
        public string Class { get; set; }
        public string Fraction { get; set; }
        public virtual ICollection<SkillModel> Skills { get; set; }
        public virtual ICollection<StateModel> State { get; set; }
    }
}
