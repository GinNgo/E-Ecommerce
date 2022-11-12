import axios from "axios";
const url = "https://localhost:44324/api/products/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetProduct: async () => await axios.get(url),
  GetCategoriesTrash: async () => await axios.get(url + "adminTrash/"),
  GetOneProduct: async (id) => await axios.get(url + id),
  GetCatParentList: async () => await axios.get(url + "catParentList/"),
  PostCreate: async (category) => await axios.post(url, category),
  PutUpdate: async (category) => await axios.put(url, category),
  PutTrash: async (ids) => await axios.put(url + "Trash/", ids),
  Delete: async (ids) => await axios.delete(url, { data: ids }),
};
