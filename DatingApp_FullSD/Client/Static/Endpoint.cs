using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DatingApp_FullSD.Client.Static
{
	public static class Endpoints
	{
		private static readonly string Prefix = "api";

		public static readonly string ProfilesEndpoint = $"{Prefix}/profiles";
		public static readonly string MatchesEndpoint = $"{Prefix}/matches";
		public static readonly string PostsEndpoint = $"{Prefix}/posts";
	}
}
