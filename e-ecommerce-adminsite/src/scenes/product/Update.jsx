import { Box, FormControl, TextField } from "@mui/material";
import Select from "react-select";
import { Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import React, { useState, useEffect } from "react";
import Header from "../../Components/Header";
import ProductApi from "../../Services/Product/ProductApi";
import CategoriesApi from "../../Services/Category/CategoriesApi";
import { useParams } from "react-router-dom";
import { Button } from "antd";
const initialValues = {
  productId: "",
  productName: "",
  descDescription: "",
  fullDescription: "",
  price: "",
  priceDiscount: "",
  quatity: "",
  originId: "",
  categories: [],
  images: [],
  brandId: "",
};

const proSchema = yup.object().shape({});

const UpdateProduct = () => {
  const isNonMoblie = useMediaQuery("(min-width:600px)");
  const { id } = useParams();
  const [responseData, setResponseData] = useState([]);
  const [product, setProduct] = useState([]);

  const handleFromSubmit = async (values) => {
    console.log(values);
  };
  const handleChanges = (selectedOption) => {
    //setParentIdChange(selectedOption);
  };
  useEffect(() => {
    fetchData();
    getProduct(id);
  }, [id]);

  const fetchData = async () => {
    try {
      const resp = await CategoriesApi.GetCatParentList();
      setResponseData(resp.data);
    } catch (error) {
      console.log(error);
    }
  };
  const getProduct = async (id) => {
    try {
      const cat = await ProductApi.GetOneProduct(id);
      setProduct(cat.data);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Box m="20px">
      <Header title="UPDATE PRODUCT" subtitle="update a Product" />
      <Formik
        onSubmit={handleFromSubmit}
        handleChange
        initialValues={initialValues}
        validationSchema={proSchema}
      >
        {({
          values,
          errors,
          touched,
          handleBlur,
          handleChange,
          handleSubmit,
        }) => (
          <form onSubmit={handleSubmit}>
            <Box
              display="grid"
              fap="30px"
              gridteamplatecolumns="repeat(4, minmax(0,1fr))"
              sx={{
                "& > div": { gridColumn: isNonMoblie ? undefined : "span 4" },
              }}
            >
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Product Name"
                value={values.productName || product.productName || ""}
                name="productName"
                error={!!errors.productName}
                helperText={errors.productName}
                onBlur={handleBlur}
                onChange={handleChange}
                sx={{ gridColumn: "span 2" }}
              />
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label=" Description"
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.fullDescription || product.fullDescription || ""}
                name="fullDescription"
                error={!!touched.fullDescription && !!errors.fullDescription}
                helperText={touched.fullDescription && errors.fullDescription}
                sx={{ gridColumn: "span 2" }}
              />
              <FormControl sx={{ gridColumn: "span 2" }}>
                <Select />
              </FormControl>
            </Box>

            <Box display="flex" justifyContent="end" mt="20px">
              <Button type="submit" color="secondary" variant="contained">
                Update product
              </Button>
            </Box>
          </form>
        )}
      </Formik>
    </Box>
  );
};

export default UpdateProduct;
