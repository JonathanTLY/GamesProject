using System;

namespace GamesProject.Shared.Domain
{
    public class Booking : BaseDomainModel
    {
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}