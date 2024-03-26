namespace FileMngt.Consts
{
    public class RouteConsts
    {
        public const string ROUTE_API_BASE = "/api";

        public const string ROUTE_FILELIST_BASE = ROUTE_API_BASE + "/filelist";
        public const string ROUTE_FILELIST_GET_ONE_BY_UUID = ROUTE_FILELIST_BASE + "/{uuid}";
    }
}
