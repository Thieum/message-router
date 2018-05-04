﻿using System;
using NetmqRouter.BusinessLogic;

namespace NetmqRouter.Infrastructure
{
    public interface IMessageRouterConfiguration
    {
        IMessageRouter WithWorkerPool(int numberOfSerializationWorkes, int numberOfHandlingWorkes);

        IMessageRouter RegisterRoute(string routeName, Type dataType);

        IMessageRouter RegisterTypeSerializerFor<T>(ITypeSerializer<T> typeSerializer);
        IMessageRouter RegisterGeneralSerializerFor<T>(IGeneralSerializer<T> serializer);

        IMessageRouter RegisterSubscriber<T>(T subscriber);
        IMessageRouter RegisterSubscriber(string routeName, Action action);
        IMessageRouter RegisterSubscriber<T>(string routeName, Action<T> action);
        IMessageRouter RegisterSubscriber<T>(string incomingRouteName, string outcomingRouteName, Func<T> action);
        IMessageRouter RegisterSubscriber<T, TK>(string incomingRouteName, string outcomingRouteName, Func<T, TK> action);
    }
}