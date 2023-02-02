using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string GenresEndpoint = $"{Prefix}/genres";
        public static readonly string AgeRatingsEndpoint = $"{Prefix}/ageratings";
        public static readonly string GamePublishersEndpoint = $"{Prefix}/gamepublishers";
        public static readonly string GamesEndpoint = $"{Prefix}/games";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string BookingsEndpoint = $"{Prefix}/bookings";

    }
}

