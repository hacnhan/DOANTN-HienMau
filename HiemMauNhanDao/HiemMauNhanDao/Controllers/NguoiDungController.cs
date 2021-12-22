using HiemMauNhanDao.Areas.Admin.Controllers;
using HiemMauNhanDao.Common;
using Models.EF;
using Models.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiemMauNhanDao.Controllers
{
    public class NguoiDungController : BaseController2
    {
        NguoiDungServices _NguoiDung = new NguoiDungServices();
        public UserLogin userSession = new UserLogin();
        private DbContextHM db = new DbContextHM();

 
        // GET: NguoiDung
        public ActionResult Index()
        {
            var session = (HiemMauNhanDao.Common.UserLogin)Session[HiemMauNhanDao.Common.CommonConstant.USER_SESSION];
            string id = session.UserID;
            ThongTinCaNhan thongTinCaNhan = db.ThongTinCaNhans.Find(id);

            if (thongTinCaNhan.hoTen == "" || thongTinCaNhan.soDT == "" || thongTinCaNhan.Email == "" || thongTinCaNhan.CCCD == "" ||
                thongTinCaNhan.gioiTinh == null || thongTinCaNhan.ngaySinh == null || thongTinCaNhan.soLanHM == null || thongTinCaNhan.nhomMau == "" ||
                thongTinCaNhan.trinhDo == "" || thongTinCaNhan.ngheNghiep == "" || thongTinCaNhan.coQuanTH == "" || thongTinCaNhan.diaChi == ""
                )
            {
                SetAlert("Vui lòng cập nhập đủ thông tin cá nhân ", "error");
            }
            return View(thongTinCaNhan);
        }

       

          public ActionResult CapnhatTTCN(string id)
        {
            ThongTinCaNhan thongTinCaNhan = db.ThongTinCaNhans.Find(id);
           
            return View(thongTinCaNhan);
        }

        [HttpPost]
        public ActionResult CapnhatTTCN(ThongTinCaNhan thongTinCaNhan)
        {
            return View(thongTinCaNhan);
        }





        //public ActionResult EditTTCN(string id)
        //{
        //    return View(_NguoiDung.GetByIdTTCN(id));
        //}
        //[HttpPost]
        //public ActionResult EditTTCN(ThongTinCaNhan thongTinCaNhan)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        ThongTinCaNhan ttcn = _NguoiDung.GetByIdTTCN(thongTinCaNhan.IdTTCN);
        //        _NguoiDung.SuaTTCN(thongTinCaNhan);
        //        SetAlert("cập nhật thành công", "success");
        //        return RedirectToAction("Index");
        //    }    
        //    else
        //    {
        //        SetAlert("Cập nhật thông tin thất bại công", "error");
        //       return RedirectToAction("Index");
        //    }
        //    return View(thongTinCaNhan);
        //}








        //[HttpPost]
        //public ActionResult Index(ThongTinCaNhan thongTinCaNhan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_NguoiDung.isExistTaiKhoan(thongTinCaNhan.userName))
        //        {
        //            ViewBag.ThongBao = "Tài khoản đã tồn tại!";
        //        }
        //        else if (_NguoiDung.isExistSDT(thongTinCaNhan.soDT))
        //        {
        //            ViewBag.ThongBao = "Số điện thoại đã tồn tại!";
        //        }
        //        else if (_NguoiDung.isExistEmail(thongTinCaNhan.Email))
        //        {
        //            ViewBag.ThongBao = "Email đã tồn tại!";
        //        }
        //        else if (_NguoiDung.isExistCCCD(thongTinCaNhan.CCCD))
        //        {
        //            ViewBag.ThongBao = "CCCD/ CMND đã tồn tại!";
        //        }
        //        else
        //        {
        //            _NguoiDung.SuaTTCN(thongTinCaNhan);
        //            SetAlert("Cập nhật thông tin thành công", "success");
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else
        //    {
        //        SetAlert("Cập nhật thông tin  thất bại ", "error");
        //        return RedirectToAction("Index");
        //    }

            
        //    return View(thongTinCaNhan);
        //}

        //[HttpPost]
        //public ActionResult EditTTCN(ThongTinCaNhan thongTinCaNhan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_NguoiDung.isExistTaiKhoan(thongTinCaNhan.CCCD))
        //        {
        //            ViewBag.ThongBao = "CCCD/ CMND đã tồn tại!";
        //        }
        //        else if (_NguoiDung.isExistTaiKhoan(thongTinCaNhan.soDT))
        //        {
        //            ViewBag.ThongBao = "Số điện thoại đã tồn tại!";
        //        }
        //        else if (_NguoiDung.isExistTaiKhoan(thongTinCaNhan.Email))
        //        {
        //            ViewBag.ThongBao = "Email đã tồn tại!";
        //        }
        //        else
        //        {
        //            var encryptedMd5Pas = Encryptor.MD5Hash(thongTinCaNhan.password);
        //            thongTinCaNhan.password = encryptedMd5Pas;
        //            _NguoiDung.SuaTTCN(thongTinCaNhan);
        //            SetAlert("Cập nhật thông tin thành công", "success");
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else
        //    {
        //        SetAlert("Cập nhật thông tin thất bại công", "success");
        //        return RedirectToAction("Index");
        //    }
        //    return View(thongTinCaNhan);          
        //}

    }
}