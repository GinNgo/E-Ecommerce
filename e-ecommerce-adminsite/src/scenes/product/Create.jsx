import { Box, Button, TextField } from "@mui/material";
import Select from "react-select";
import { Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import React, { useState, useEffect } from "react";
import Header from "../../Components/Header";
import Categories from "../../Services/Category/CategoriesApi";
import { Editor } from "@tinymce/tinymce-react";
const initialValues = {
  categoryName: "",
  categoryDescription: "",
  parentId: 0,
};

const catSchema = yup.object().shape({
  categoryName: yup.string().required("reaquired"),
  categoryDescription: yup.string().required("reaquired"),
});

const CreateProduct = () => {
  const isNonMoblie = useMediaQuery("(min-width:600px)");
  const handleFromSubmit = (values) => {
    values.parentId = parentId;

    console.log(values);
  };

  const [responseData, setResponseData] = useState([]);
  const [parentId, setParentId] = useState(0);
  const handleChanges = (selectedOption) => {
    setParentId(selectedOption.value);
  };
  useEffect(() => {
    fetchData();
  }, []);
  const fetchData = async () => {
    try {
      const resp = await Categories.GetCatParentList();

      setResponseData(resp.data);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Box m="20px">
      <Header title="CREATE CATEGORY" subtitle="Ceate new a Catalog" />
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
                label="Category Name"
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.categoryName}
                name="categoryName"
                error={!!touched.categoryName && !!errors.categoryName}
                helperText={touched.categoryName && errors.categoryName}
                sx={{ gridColumn: "span 2" }}
              />
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Category Description"
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.categoryDescription}
                name="categoryDescription"
                error={
                  !!touched.categoryDescription && !!errors.categoryDescription
                }
                helperText={
                  touched.categoryDescription && errors.categoryDescription
                }
                sx={{ gridColumn: "span 2" }}
              />

              <Select
                fullWidth
                variant="filled"
                name="parentId"
                isClearable={true}
                isSearchable={true}
                options={responseData}
                onBlur={handleBlur}
                onChange={(handleChange, handleChanges)}
              />
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
