//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TDMT_DOAN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.BANGGHIDAUGIAs = new HashSet<BANGGHIDAUGIA>();
            this.CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            this.CHITIETHOPDONGBANHANGs = new HashSet<CHITIETHOPDONGBANHANG>();
            this.CHITIETHOPDONGMUAHANGs = new HashSet<CHITIETHOPDONGMUAHANG>();
            this.HOPDONGMUAHANGs = new HashSet<HOPDONGMUAHANG>();
        }
    
        public string MA { get; set; }
        public string TEN { get; set; }
        public Nullable<double> DONGIAMUA { get; set; }
        public Nullable<double> DONGIABAN { get; set; }
        public string HINHANH { get; set; }
        public string MOTA { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<int> LOAISANPHAM { get; set; }
        public Nullable<bool> SANPHAMMOI { get; set; }
        public Nullable<int> NHASANXUAT { get; set; }
        public Nullable<bool> SANPHAMBANCHAY { get; set; }
        public Nullable<bool> DAXOA { get; set; }
        public Nullable<bool> SANPHAMBAN { get; set; }
        public Nullable<int> MAKHUYENMAI { get; set; }
        public Nullable<bool> DAUGIA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGGHIDAUGIA> BANGGHIDAUGIAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOPDONGBANHANG> CHITIETHOPDONGBANHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOPDONGMUAHANG> CHITIETHOPDONGMUAHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONGMUAHANG> HOPDONGMUAHANGs { get; set; }
        public virtual LOAISANPHAM LOAISANPHAM1 { get; set; }
        public virtual NHASANXUAT NHASANXUAT1 { get; set; }
    }
}
