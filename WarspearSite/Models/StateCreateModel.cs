namespace WarspearSite.Models
{
    public class StateCreateModel
    {
        public Guid? Id { get; set; }
        public Guid HeroId { get; set; }
        public int Health { get; set; }
        public int HealthRegeneration { get; set; }
        public int Energy { get; set; }
        public int EnergyRegeneration { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicalDefence { get; set; }
        public int PhisicalDamage { get; set; }
        public int MagicalDamage { get; set; }
        public decimal CritHit { get; set; }
        public decimal Accyarcy { get; set; }// точность
        public decimal? AttackSpeed { get; set; }
        public decimal? Penetration { get; set; }//пробив
        public decimal? SkillCooldown { get; set; }
        public decimal? Stun { get; set; }
        public decimal? Rage { get; set; }
        public decimal Ferocity { get; set; }//арена
        public decimal? AttackStrength { get; set; }//авта
        public decimal? DepthsFury { get; set; }//урон вода
        public decimal? PiercingAttack { get; set; }//пронза
        public decimal Dodge { get; set; }//уклон
        public decimal Resilience { get; set; }//устой
        public decimal? Parry { get; set; }
        public decimal? Block { get; set; }
        public decimal? StealHelth { get; set; }//вамп
        public decimal? DamageReflection { get; set; }//отражение
        public decimal Solidity { get; set; }//надега
        public decimal? Resistance { get; set; }//сопра
    }
}
