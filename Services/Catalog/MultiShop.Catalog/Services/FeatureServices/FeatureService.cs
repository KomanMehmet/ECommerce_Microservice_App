using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings databasesettings)
        {
            var client = new MongoClient(databasesettings.ConnectionString);
            var database = client.GetDatabase(databasesettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databasesettings.FeatureCollectionName);

            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);

            await _featureCollection.InsertOneAsync(values);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var value = await _featureCollection.Find<Feature>(x => x.FeatureID == id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdFeatureDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);

            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDto.FeatureID, value);
        }
    }
}
