import axios from "axios";
const url = "https://localhost:44324/api/products/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetProduct: async () => await axios.get(url),
  GetProductsTrash: async () => await axios.get(url + "adminTrash/"),
  GetOneProduct: async (id) => await axios.get(url + id),
  GetCatParentList: async () => await axios.get(url + "catParentList/"),
  PostCreate: async (product) => await axios.post(url, product),
  PutUpdate: async (product) => await axios.put(url, product),
  PutTrash: async (ids) => await axios.put(url + "Trash/", ids),
  Delete: async (ids) => await axios.delete(url, { data: ids }),
};
