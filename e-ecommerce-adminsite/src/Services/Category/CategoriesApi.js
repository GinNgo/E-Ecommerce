import axios from "axios";
const url = "https://localhost:44324/api/categories/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetCategories: async () => await axios.get(url + "admin/"),
  GetCategoriesTrash: async () => await axios.get(url + "adminTrash/"),
  GetOneCategory: async (id) => await axios.get(url + id),
  GetCatParentList: async () => await axios.get(url + "catParentList/"),
  PostCreate: async (category) => await axios.post(url, category),
  PutUpdate: async (category) => await axios.put(url, category),
  PutTrash: async (ids) => await axios.put(url + "Trash/", ids),
  Delete: async (ids) => await axios.delete(url, { data: ids }),
};
