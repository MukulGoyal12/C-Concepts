//add a function to fetch and display vehicles
async function fetchVehicles() {
   // alert("fetching vehicles...");
    try {
        const response = await fetch('http://localhost:5020/api/vehicle');
        const vehicles = await response.json();
        const vehicleList = document.getElementById('content');
        vehicleList.innerHTML = '';
        vehicles.forEach(vehicle => {
            const vehicleItem = document.createElement('li');
            vehicleItem.className = 'list-group-item';
            vehicleItem.textContent = `${vehicle.type} ${vehicle.model}  (${vehicle.regnNo}) (${vehicle.year}) - ${vehicle.engnieCapacity}`;
            vehicleList.appendChild(vehicleItem);
        });
    } catch (error) {
        console.error('Error fetching vehicles:', error);
    }
}

// Call the function to fetch and display vehicles when the page loads
document.addEventListener('DOMContentLoaded', fetchVehicles);