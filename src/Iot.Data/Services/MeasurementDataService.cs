using Iot.Data.Dtos;
using Iot.Data.Interfaces;
using Iot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iot.Data.Services
{
    public class MeasurementDataService : IMeasurementDataService
    {
        private readonly IMeasurementContentHandler _measurementContentHandler;
        private readonly IMeasurementRepository _measurementRepository;

        public MeasurementDataService(IMeasurementContentHandler measurementContentHandler, IMeasurementRepository measurementRepository)
        {
            _measurementContentHandler = measurementContentHandler;
            _measurementRepository = measurementRepository;
        }

        public async Task<IEnumerable<MeasurementDto>> GetAsync(string deviceId, DateTime date, SensorType sensorType)
        {
            BinaryData content = await _measurementRepository.GetContentAsync(deviceId, date, sensorType);
            IEnumerable<MeasurementDto> records = _measurementContentHandler.Handle(content);

            return records;
        }
    }
}
