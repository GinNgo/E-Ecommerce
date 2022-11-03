import axios from "axios";
const url = "https://localhost:44324/api/categories/";
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  GetCategories: async () => await axios.get(url + "admin/"),
  GetProduct: async (PageIndex, PageSize) =>
    await axios.post(url + "GetProductPaging/", { PageIndex, PageSize }),
};
