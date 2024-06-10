using API_QLSV.Adapters;
using API_QLSV.Models;
using lib.Entity;
using lib.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_QLSV.Controllers.api
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private IStudentsService StudentsService;
        private readonly IStudentAdapter _studentAdapter;

        public StudentsController(IStudentsService StudentsService, IStudentAdapter studentAdapter)
        {
            this.StudentsService = StudentsService;
            this._studentAdapter = studentAdapter;
        }
        [HttpGet("get-Student")]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(new { status = true, message = "success", data = StudentsService.GetStudentsList() });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }



        //public async Task<ActionResult> SendMail(string Receiver, string Subject, string body)
        //{
        //    try
        //    {
        //        var client = new HttpClient();
        //        var request = new HttpRequestMessage(HttpMethod.Post, "https://app.zetamail.vn/api/sendmail/");
        //        var content = new MultipartFormDataContent();
        //        content.Add(new StringContent(Subject), "Subject");
        //        content.Add(new StringContent("Van Duong"), "FromName");
        //        content.Add(new StringContent("tuyensinh@huflit.edu.vn"), "FromAddress");
        //        content.Add(new StringContent("tuyensinh@huflit.edu.vn"), "ReplyTo");
        //        content.Add(new StringContent(body), "TextBody");
        //        content.Add(new StringContent(""), "HTMLBody");
        //        content.Add(new StringContent(Receiver), "ToAddress");
        //        content.Add(new StringContent("Văn"), "ToName");
        //        content.Add(new StringContent(""), "token");
        //        content.Add(new StringContent(""), "cc");
        //        content.Add(new StringContent(""), "bcc");
        //        content.Add(new StringContent("1"), "queue");

        //        request.Content = content;
        //        var response = await client.SendAsync(request);
        //        response.EnsureSuccessStatusCode();
        //        string msg = await response.Content.ReadAsStringAsync();

        //        return Ok(new { status = true, message = msg });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex });
        //    }
        //}




        [HttpPost("insert-Student")]
        public async Task<ActionResult> InsertStudents(StudentsModel Student)
        {
            try
            {
                //Students st = new Students();
                //st.MaSinhVien = Student.MaSinhVien;
                //st.HoLot = Student.HoLot;
                //st.Ten = Student.Ten;
                //st.NgaySinh = Student.NgaySinh;
                //st.GioiTinh = Student.GioiTinh;
                //st.DanToc = Student.DanToc;
                //st.TonGiao = Student.TonGiao;
                //st.TrangThai = Student.TrangThai;
                StudentsService.InsertStudents(_studentAdapter.Adapt(Student));
                return Ok(new { status = true, message = "success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("change-Student")]
        public async Task<ActionResult> ChangeStudents(StudentsModel Student)
        {
            try
            {
                Students st = new Students();
                st.MaSinhVien = Student.MaSinhVien;
                st.HoLot = Student.HoLot;
                st.Ten = Student.Ten;
                st.NgaySinh = Student.NgaySinh;
                st.GioiTinh = Student.GioiTinh;
                st.DanToc = Student.DanToc;
                st.TonGiao = Student.TonGiao;
                st.TrangThai = Student.TrangThai;
                StudentsService.ChangeStudents(st);
                return Ok(new { status = true, message = "success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("delete-Student")]
        public async Task<ActionResult> DeleteStudents(StudentsModel Student)
        {
            try
            {
                Students st = new Students();
                st.MaSinhVien = Student.MaSinhVien;
                StudentsService.DeleteStudents(st);
                return Ok(new { status = true, message = "success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
