// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>



                            namespace Dominio.Entitys
                            {
                                public class T_FavoritosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_FavoritosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_FavoritosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_FavoritosEntity Create(int idfavorito, int use_id, int id_indicador )
                            {
                                return Create(null, idfavorito, use_id, id_indicador);
                            }

                            public IT_FavoritosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int idfavorito, int use_id, int id_indicador )
                            {
                            var entity = new T_FavoritosEntity(idfavorito, use_id, id_indicador );


                            var trackingMask = _trackingPolicy?.GetMask("T_Favoritos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_FavoritosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration