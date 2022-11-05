import axios from "axios";
const url = "https://localhost:44324/api/categories/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetCategories: async () => await axios.get(url + "admin/"),
  GetCatParentList: async () => await axios.get(url + "catParentList/"),
  PostCreate: async (category) => await axios.post(url, category),
};
