using BlogDemo.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.core.Entities
{
    public abstract class Entity: IEntity
    {
        public int Id { get; set; }
    }
}
