import { Box, Button, FormControl, TextField } from "@mui/material";
import Select from "react-select";
import { Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import React, { useState, useEffect } from "react";
import Header from "../../Components/Header";
import Categories from "../../Services/Category/CategoriesApi";
import { useParams } from "react-router-dom";

const initialValues = {
  categoryName: "",
  categoryDescription: "",
  parentId: "",
};

const catSchema = yup.object().shape({
  categoryName: yup.string().required("reaquired"),
  categoryDescription: yup.string().required("reaquired"),
});

const UpdateCategory = () => {
  const isNonMoblie = useMediaQuery("(min-width:600px)");
  const { id } = useParams();
  const handleFromSubmit = async (values) => {
    values.parentId = parentId;

    console.log(values);
  };

  const [responseData, setResponseData] = useState([]);
  const [category, setCategory] = useState([]);
  const [parentId, setParentId] = useState(0);
  const handleChanges = (selectedOption) => {
    if (!selectedOption) setParentId(selectedOption.value);
  };
  useEffect(() => {
    getCategory(id);

    fetchData();
  }, [id]);
  const fetchData = async () => {
    try {
      const resp = await Categories.GetCatParentList();
      setResponseData(resp.data);
    } catch (error) {
      console.log(error);
    }
  };
  const getCategory = async (id) => {
    try {
      const category = await Categories.GetOneCategory(id);
      setCategory(category.data);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <Box m="20px">
      <Header title="UPDATE CATEGORY" subtitle="update a Catagory" />
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
                defaultValue={values.categoryName}
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
                defaultValue={values.categoryDescription || ""}
                name="categoryDescription"
                error={
                  !!touched.categoryDescription && !!errors.categoryDescription
                }
                helperText={
                  touched.categoryDescription && errors.categoryDescription
                }
                sx={{ gridColumn: "span 2" }}
              />
              <FormControl
                sx={{ gridColumn: "span 2" }}
                onChange={handleChange}
              >
                <Select
                  className="basic-single"
                  classNamePrefix="select"
                  fullWidth
                  variant="filled"
                  name="parentId"
                  isClearable={true}
                  isSearchable={true}
                  onChange={(handleChange, handleChanges)}
                  options={responseData}
                  defaultValue={category.parentId}
                />
              </FormControl>
            </Box>

            <Box display="flex" justifyContent="end" mt="20px">
              <Button type="submit" color="secondary" variant="contained">
                Update category
              </Button>
            </Box>
          </form>
        )}
      </Formik>
    </Box>
  );
};

export default UpdateCategory;
