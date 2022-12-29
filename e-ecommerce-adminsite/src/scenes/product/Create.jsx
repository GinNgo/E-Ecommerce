import { Box, Button, TextField } from "@mui/material";
import Select from "react-select";
import { Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import React, { useState, useEffect } from "react";
import Header from "../../Components/Header";
import Categories from "../../Services/Category/CategoriesApi";
import Origins from "../../Services/Origin/OriginApi";
import Brands from "../../Services/Brand/BrandApi";
import { useRef } from "react";
import { Editor } from "@tinymce/tinymce-react";
import ProductApi from "../../Services/Product/ProductApi";
import ImageApi from "../../Services/Image/ImageApi";
import { Link } from "react-router-dom";
import KeyboardBackspaceOutlinedIcon from "@mui/icons-material/KeyboardBackspaceOutlined";
const initialValues = {
  productName: "",
  fullDescription: "",
  categories: [],
  price: "",
  priceDiscount: "",
  quantity: "",
  originId: "",
  brandId: "",
};

const catSchema = yup.object().shape({
  productName: yup.string().required("reaquired"),
  price: yup.string().required("reaquired"),
  priceDiscount: yup.string().required("reaquired"),
  quantity: yup.string().required("reaquired"),
});

const CreateProduct = () => {
  const isNonMoblie = useMediaQuery("(min-width:600px)");
  const handleFromSubmit = async (values) => {
    values.categories = categories;
    values.brandId = brandId.value;
    values.originId = originId.value;
    values.fullDescription = editorRef.current.getContent();
    var result = await ProductApi.PostCreate(values);
    console.log(result);
    const files = [...MultipleFiles];
    files.forEach((file, index) => {
      const formData = new FormData();
      formData.append("id", result.data);
      formData.append("displayOrder", index + 1);
      formData.append("filename", file);
      ImageApi.PostImage(formData);
    });
    window.location.href = "/Product";
  };

  const [categoryData, setCategoryData] = useState([]);
  const [originData, setOriginData] = useState([]);
  const [brandData, setBrandData] = useState([]);
  const [categories, setcategoriesId] = useState([]);
  const [brandId, setBrandId] = useState([]);
  const [originId, setoriginId] = useState([]);
  const [MultipleFiles, setMultipleFiles] = useState("");
  const editorRef = useRef();
  const MultipleFileChange = (e) => {
    setMultipleFiles(e.target.files);
  };

  const handleChanges = (selectedOption) => {
    setcategoriesId(selectedOption);
  };
  const handleOriginChanges = (selectedOption) => {
    setoriginId(selectedOption);
  };
  const handleBrandChanges = (selectedOption) => {
    setBrandId(selectedOption);
  };
  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    try {
      const catList = await Categories.GetCatParentList();
      setCategoryData(catList.data);

      const originList = await Origins.GetOrigin();
      setOriginData(originList.data);

      const brandList = await Brands.GetBrand();
      setBrandData(brandList.data);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Box m="20px">
      <Header title="CREATE PRODUCT" subtitle="Ceate new a Product" />
      <Link to={`/product`} style={{ listStyleType: "none" }}>
        <Button color="secondary" variant="contained">
          <KeyboardBackspaceOutlinedIcon />
          BACK TO PRODUCT
        </Button>
      </Link>
      <Formik
        onSubmit={handleFromSubmit}
        handleChange
        initialValues={initialValues}
        validationSchema={catSchema}
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
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.productName}
                name="productName"
                error={!!touched.productName && !!errors.productName}
                helperText={touched.productName && errors.productName}
              />
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Product Price"
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.price}
                name="price"
                error={!!touched.price && !!errors.price}
                helperText={touched.price && errors.price}
              />
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Product PriceDiscount"
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.priceDiscount}
                name="priceDiscount"
                error={!!touched.priceDiscount && !!errors.priceDiscount}
                helperText={touched.priceDiscount && errors.priceDiscount}
              />
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Quantity"
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.quantity}
                name="quantity"
                error={!!touched.quantity && !!errors.quantity}
                helperText={touched.quantity && errors.quantity}
              />
              <Editor
                label="Product Description"
                onInit={(evt, editor) => (editorRef.current = editor)}
                init={{
                  selector: "textarea.codedemo",

                  menubar: true,
                  width: "1200px",
                  plugins: "code",
                }}
              />

              <br />
              <label>Categories:</label>
              <Select
                fullWidth
                isMulti
                name="CategoriesId"
                options={categoryData}
                onChange={handleChanges}
                className="basic-multi-select"
                classNamePrefix="select"
              />
              <label>Origin:</label>
              <Select
                fullWidth
                variant="filled"
                name="originId"
                isClearable={true}
                isSearchable={true}
                options={originData}
                onChange={handleOriginChanges}
              />
              <label>Brand:</label>
              <Select
                fullWidth
                variant="filled"
                name="brandId"
                isClearable={true}
                isSearchable={true}
                options={brandData}
                onChange={handleBrandChanges}
              />
              <br />
              <Box>
                <label>Chọn hình ảnh</label>
                <input
                  type="file"
                  multiple
                  onChange={(e) => MultipleFileChange(e)}
                />
              </Box>
            </Box>

            <Box display="flex" justifyContent="end" mt="20px">
              <Button type="submit" color="secondary" variant="contained">
                Create New Product
              </Button>
            </Box>
          </form>
        )}
      </Formik>
    </Box>
  );
};

export default CreateProduct;
