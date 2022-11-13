﻿using AutoMapper;
using Span.Culturio.Api.Models.Subscriptions;
using Span.Culturio.Api.Data.Entities;

namespace Span.Culturio.Api.Profiles {
    public class SubscriptionProfile : Profile {
        public SubscriptionProfile() {
            CreateMap<CreateSubscriptionDto, Subscription>()
                .ForMember(dest => dest.Id, otp => otp.Ignore())
                .ForMember(dest => dest.ActiveFrom, otp => otp.Ignore())
                .ForMember(dest => dest.ActiveTO, otp => otp.Ignore())
                .ForMember(dest => dest.State, otp => otp.Ignore())
                .ForMember(dest => dest.RecordedVisits, otp => otp.Ignore())
                .ForMember(dest => dest.User, otp => otp.Ignore())
                .ForMember(dest => dest.Package, otp => otp.Ignore());
            CreateMap<Subscription, SubscriptionDto>();
        }
    }
}
