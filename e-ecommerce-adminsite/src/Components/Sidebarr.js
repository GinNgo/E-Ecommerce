import React from "react";
import ProductApi from "../services/product/ProductApi";

const Sidebar = () => {
  // Create state variables
  let [responseData, setResponseData] = React.useState("");
  // fetches data
  const fetchData = async (e, { PageIndex, PageSize }) => {
    e.preventDefault();
    try {
      const resp = await ProductApi.GetProductPaging(PageIndex, PageSize);
      setResponseData(resp.data);
      console.log(resp.data);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <div>
      <h1>{responseData.totalCount}</h1>
      <button
        onClick={(e) => fetchData(e, { PageIndex: 1, PageSize: 5 })}
        type="button"
      >
        Click Me For Data
      </button>
      {responseData.products &&
        responseData.products.map((date) => {
          return <p>{date.productName}</p>;
        })}
    </div>
  );
};
export default Sidebar;
