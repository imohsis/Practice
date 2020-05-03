using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRACTICE.MODEL;
using PRACTICE.REPOSITORY;
using PRACTICE.REPOSITORY.Contracts;

namespace PRACTICE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        public static ReturnObject _retObj;
        private readonly IMemberRepository _memberRepository;
       

        public const string _errMsg = "An error occured while processing your request.";

        static MembersController()
        {
            _retObj = new ReturnObject { Id = 0, Status = false, StatusMessage = "", Data = { } };
        }
        public MembersController(IMemberRepository memberRepository)
        {
            
            _memberRepository = memberRepository;
        }


        [HttpGet]
        [Route("All")]
        public async Task<ReturnObject> Get()
        {
            try
            {
                var obj = await _memberRepository.GetAllMember();
                _retObj.Data = obj;
                _retObj.Status = true;
                _retObj.StatusMessage = "Successful!";

                return _retObj;
            }
            catch (Exception ex)
            {
                _retObj.Status = false;
                _retObj.StatusMessage = $"{_errMsg} {ex.Message}";
                _retObj.Data = null;
                return _retObj;
            }
            //return await this._memberRepository.GetAllMember();
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ReturnObject> Get(int Id)
        {
            try
            {
                var obj = await _memberRepository.GetMemberById(Id);
                _retObj.Data = obj;
                _retObj.Status = true;
                _retObj.StatusMessage = "Successful!";

                return _retObj;
            }
            catch (Exception ex)
            {
                _retObj.Status = false;
                _retObj.StatusMessage = $"{_errMsg} {ex.Message}";
                _retObj.Data = null;
                return _retObj;
            }
            
            //return await this._memberRepository.GetMemberById(Id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ReturnObject> Post([FromBody]Member member)
        {


            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

                _retObj.Status = false;
                _retObj.StatusMessage = errorMessages;
                return _retObj;
            }

            try
            {
    
                var ret = await _memberRepository.AddMember(member);
                return ret;
            }
            catch (Exception ex)
            {
                _retObj.Status = false;
                _retObj.StatusMessage = $"An error occured while processing your request. {ex.Message}";
                _retObj.Data = null;

                return _retObj;
            }
            
            //await this._memberRepository.AddMember(member);
        }

        [HttpPut]
        [Route("ById/{id}")]
        public async Task<ReturnObject> Put(int UserId, [FromBody]Member member)
        {
            
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

                _retObj.Status = false;
                _retObj.StatusMessage = errorMessages;
                return _retObj;
            }

            try
            {
                var ret = await _memberRepository.UpdateMember(member);
                return ret;
            }
            catch (Exception ex)
            {
                _retObj.Status = false;
                _retObj.StatusMessage = $"An error occured while processing your request. {ex.Message}";
                _retObj.Data = null;

                return _retObj;
            }
            //await this._memberRepository.UpdateMember(members);
        }

        [HttpDelete]
        [Route("ById/{id}")]
        public async Task<ReturnObject> Delete(int Id)
        {

            try
            {
                var obj = await _memberRepository.DeleteMember(Id);
                _retObj.Data = obj;
                _retObj.Status = true;
                _retObj.StatusMessage = "Successful!";

                return _retObj;
            }
            catch (Exception ex)
            {
                _retObj.Status = false;
                _retObj.StatusMessage = $"{_errMsg} {ex.Message}";
                _retObj.Data = null;
                return _retObj;
            }
            

            //await this._memberRepository.DeleteMember(Id);
        }
    }
}



