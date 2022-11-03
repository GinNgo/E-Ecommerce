import axios from "axios";
const url = "https://localhost:44324/api/products/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetProduct: async () => await axios.get(url),
};
