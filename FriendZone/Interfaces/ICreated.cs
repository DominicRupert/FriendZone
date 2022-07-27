using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendZone.Models;

namespace FriendZone.Interfaces
{
    public interface ICreated
    {
        string CreatorId { get; set; }
        Profile Creator { get; set; }
        
    }
}