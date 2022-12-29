import axios from "axios";
const url = "https://localhost:44324/api/brands/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetBrand: async () => await axios.get(url),
};
