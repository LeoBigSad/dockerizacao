﻿using Academia.Domain.DTO;
using Academia.Domain.Models;


namespace Academia.Domain.Interfaces.Service
{
    public interface IAparelhoService
    {
        Task<ResultData<bool>> AddAparelho(Aparelho aparelho);
        Task<ResultData<Aparelho>> GetAparelhoById(Guid id);
        Task<ResultData<List<Aparelho>>> GetAparelhos();
        Task<ResultData<Aparelho>> UpdateAparelho(Guid id, Aparelho updatedAparelho);
        Task<ResultData<bool>> DeleteAparelho(Guid aparelhoId);
    }
}
