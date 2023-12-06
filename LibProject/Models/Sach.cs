using System;
using System.Collections.Generic;

namespace LibProject.Models;

public partial class Sach
{
    public int Id { get; set; }

    public string? TenSach { get; set; }

    public string? TacGia { get; set; }

    public string? NhaXuatBan { get; set; }

    public int? SoLuong { get; set; }
}
