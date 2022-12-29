import axios from "axios";
const url = "https://localhost:44324/api/file/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  PostImage: async (formData) => await axios.post(url, formData),
};
