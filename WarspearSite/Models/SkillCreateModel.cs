﻿namespace WarspearSite.Models
{
    public class SkillCreateModel
    {
        public Guid? Id { get; set; }
        public Guid HeroId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SkillPoint { get; set; }

    }
}
