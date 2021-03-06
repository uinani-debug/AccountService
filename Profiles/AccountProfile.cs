﻿using AccountLibrary.API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountLibrary.API.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Entities.Account, Models.AvailableBalance>()
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => $"{src.available_balance}"));

            CreateMap<Entities.Account, Models.AccountDto>()
                .ForMember(
                    dest => dest.AccountIdentifier,
                    opt => opt.MapFrom(src => $"{src.account_identifier}"))
                .ForMember(
                    dest => dest.AccountType,
                    opt => opt.MapFrom(src => $"{src.account_type}"))
                 .ForMember(
                    dest => dest.AccountSubType,
                    opt => opt.MapFrom(src => $"{src.account_sub_type}"))
                    .ForMember(
                     dest => dest.AvailableBalance,
                     opt => opt.ResolveUsing(o => MapAmount(o.available_balance)))
                      .ForMember(
                    dest => dest.SortCode,
                    opt => opt.MapFrom(src => $"{src.sort_code}"))

                          .ForMember(
                    dest => dest.InterestRate,
                    opt => opt.MapFrom(src => $"{src.interest_rate}"))

                   .ForMember(
                    dest => dest.AccountStatus,
                    opt => opt.MapFrom(src => $"{src.account_status}"));
                     
        }

        public static AvailableBalance MapAmount(double amount)
        {
            return new AvailableBalance
            {
                Amount = amount,
                Currency = "GBP"
            };

        }
    }
}
