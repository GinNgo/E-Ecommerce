import axios from "axios";
const url = "https://localhost:44324/api/origins/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetOrigin: async () => await axios.get(url),
};
