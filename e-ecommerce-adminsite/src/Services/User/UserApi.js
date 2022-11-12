import axios from "axios";
const url = "https://localhost:44324/api/user/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetCustomer: async () => await axios.get(url),
};
