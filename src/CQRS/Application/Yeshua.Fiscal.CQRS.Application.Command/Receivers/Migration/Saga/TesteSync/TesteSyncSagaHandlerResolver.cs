// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using RepositoryInterfaces.Patterns.Saga;
using Dominio.Saga;
using System;
using System.Collections.Generic;

namespace Command.Receivers
{
    public class TesteSyncSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly TesteSyncPasso1Handler _TesteSyncPasso1Handler;
        private readonly TesteSyncPasso2Handler _TesteSyncPasso2Handler;
        private readonly TesteSyncPasso3Handler _TesteSyncPasso3Handler;
        private readonly TesteSyncPasso4Handler _TesteSyncPasso4Handler;
        private readonly TesteSyncPasso5Handler _TesteSyncPasso5Handler;

        public TesteSyncSagaHandlerResolver(TesteSyncPasso1Handler TesteSyncPasso1Handler, TesteSyncPasso2Handler TesteSyncPasso2Handler, TesteSyncPasso3Handler TesteSyncPasso3Handler, TesteSyncPasso4Handler TesteSyncPasso4Handler, TesteSyncPasso5Handler TesteSyncPasso5Handler)
        {
            _TesteSyncPasso1Handler = TesteSyncPasso1Handler;
            _TesteSyncPasso2Handler = TesteSyncPasso2Handler;
            _TesteSyncPasso3Handler = TesteSyncPasso3Handler;
            _TesteSyncPasso4Handler = TesteSyncPasso4Handler;
            _TesteSyncPasso5Handler = TesteSyncPasso5Handler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { TesteSyncSaga.STEP_1, _TesteSyncPasso1Handler },
                { TesteSyncSaga.STEP_2, _TesteSyncPasso2Handler },
                { TesteSyncSaga.STEP_3, _TesteSyncPasso3Handler },
                { TesteSyncSaga.STEP_4, _TesteSyncPasso4Handler },
                { TesteSyncSaga.STEP_5, _TesteSyncPasso5Handler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers