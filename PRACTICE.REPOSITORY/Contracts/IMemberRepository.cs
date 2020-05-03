using PRACTICE.MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICE.REPOSITORY.Contracts
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMember();

        Task<Member> GetMemberById(int Id);

        Task<ReturnObject> AddMember(Member member);

        Task<ReturnObject> UpdateMember(Member member);

        Task<ReturnObject> DeleteMember(int Id);
    }
}

//Task<ReturnObject> AddAsync(TipChannel obj);
//Task<ReturnObject> DeleteByIdAsync(int id);
//Task<List<TipChannel>> GetAllAsync();
//Task<TipChannel> GetByIdAsync(int id);
//Task<ReturnObject> UpdateAsync(TipChannelModel obj);