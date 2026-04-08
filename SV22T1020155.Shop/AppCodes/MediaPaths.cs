namespace SV22T1020155.Shop
{
    /// <summary>
    /// Thư mục lưu ảnh chung với Admin (thư mục image) — đường dẫn trong appsettings Image:Root.
    /// </summary>
    public static class MediaPaths
    {
        public static string ResolveRoot(IWebHostEnvironment env, IConfiguration config)
        {
            var configured = config["Image:Root"];
            if (string.IsNullOrWhiteSpace(configured))
                configured = Path.Combine("..", "image");
            var full = Path.GetFullPath(Path.Combine(env.ContentRootPath, configured));
            Directory.CreateDirectory(Path.Combine(full, "products"));
            Directory.CreateDirectory(Path.Combine(full, "employees"));
            return full;
        }

        public static string ProductsPath(IWebHostEnvironment env, IConfiguration config) =>
            Path.Combine(ResolveRoot(env, config), "products");
    }
}
