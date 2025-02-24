  <template>
    <div class="container">
      <input 
        v-model="filter" 
        placeholder="Filter by name or car..." 
        class="input-filter"
      />
      <table class="car-table">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="car in paginatedCars" :key="car.id">
            <td>{{ car.id }}</td>
            <td>{{ car.name }}</td>
          </tr>
        </tbody>
      </table>
  
      <div class="pagination">
        <button 
          @click="prevPage" 
          :disabled="currentPage === 1"
          class="pagination-button prev-next"
        >
          Previous
        </button>
        <span class="pagination-info">
          Page {{ currentPage }} of {{ totalPages }}
        </span>
        <button 
          @click="nextPage" 
          :disabled="currentPage === totalPages"
          class="pagination-button prev-next"
        >
          Next
        </button>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent, ref, computed, onMounted } from 'vue';
  import axios from 'axios';
  
  export default defineComponent({
    setup() {
      interface Car {
        id: number;
        name: string;
      }
  
      const cars = ref<Car[]>([]);
      const filter = ref('');
      const currentPage = ref(1);
      const itemsPerPage = 5;
  
      const fetchCars = async () => {
        const response = await axios.get('http://localhost:5254/api/cars');
        cars.value = response.data;
      };
  
      const filteredCars = computed(() => {
        return cars.value.filter(car => 
          car.name.toLowerCase().includes(filter.value.toLowerCase())
        );
      });
  
      const totalPages = computed(() => {
        return Math.ceil(filteredCars.value.length / itemsPerPage);
      });
  
      const paginatedCars = computed(() => {
        const start = (currentPage.value - 1) * itemsPerPage;
        const end = start + itemsPerPage;
        return filteredCars.value.slice(start, end);
      });
  
      const nextPage = () => {
        if (currentPage.value < totalPages.value) {
          currentPage.value++;
        }
      };
  
      const prevPage = () => {
        if (currentPage.value > 1) {
          currentPage.value--;
        }
      };
  
      onMounted(() => {
        fetchCars();
      });
  
      return { 
        cars, 
        filter, 
        filteredCars, 
        paginatedCars, 
        currentPage, 
        totalPages, 
        nextPage, 
        prevPage 
      };
    },
  });
  </script>
  
  <style>
  .container {
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
    font-family: Arial, sans-serif;
  }
  
  .input-filter {
    width: 100%;
    padding: 10px;
    font-size: 16px;
    border-radius: 5px;
    border: 1px solid #ccc;
    margin-bottom: 20px;
    transition: border-color 0.3s ease;
  }
  
  .input-filter:focus {
    border-color: #007bff;
    outline: none;
    box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
  }
  
  .car-table {
    width: 100%;
    border-collapse: collapse;
    background-color: #fff;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  }
  
  .car-table th,
  .car-table td {
    padding: 12px;
    text-align: left;
    border-bottom: 1px solid #ddd;
  }
  
  .car-table th {
    background-color: #343a40;
    color: white;
    font-weight: bold;
  }
  
  .car-table tr:hover {
    background-color: #f5f5f5;
  }
  
  .pagination {
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 20px;
    gap: 10px;
  }
  
  .pagination-button {
    padding: 8px 16px;
    border: none;
    border-radius: 5px;
    background-color: #343a40;
    color: white;
    cursor: pointer;
    transition: background-color 0.3s ease;
  }
  
  .pagination-button:disabled {
    background-color: #6c757d;
    cursor: not-allowed;
  }
  
  .pagination-button:hover:not(:disabled) {
    background-color: #007bff;
  }
  
  .pagination-info {
    font-size: 14px;
    color: #343a40;
    font-weight: bold;
  }
  </style>