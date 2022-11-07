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
  categoryId: "",
  categoryName: "",
  categoryDescription: "",
  parentId: "",
};

const catSchema = yup.object().shape({});

const UpdateCategory = () => {
  const isNonMoblie = useMediaQuery("(min-width:600px)");
  const { id } = useParams();

  const [responseData, setResponseData] = useState([]);
  const [category, setCategory] = useState([]);
  const [parentIdChange, setParentIdChange] = useState("");
  const { categoryId, categoryName, categoryDescription, parentId } = category;

  const handleFromSubmit = async (values) => {
    if (values.categoryName === "") values.categoryName = categoryName;
    if (values.categoryDescription === "")
      values.categoryDescription = categoryDescription;
    values.parentId = parentIdChange.value;
    values.categoryId = categoryId;
    values.createBy = category.createBy;
    values.updateBy = category.createDate;
    var result = await Categories.PutUpdate(values);
    console.log(result);
  };
  const handleChanges = (selectedOption) => {
    setParentIdChange(selectedOption);
  };
  useEffect(() => {
    fetchData();
    getCategory(id);
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
      const cat = await Categories.GetOneCategory(id);
      setCategory(cat.data);
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
                value={values.categoryName || categoryName || ""}
                name="categoryName"
                error={!!errors.categoryName}
                helperText={errors.categoryName}
                onBlur={handleBlur}
                onChange={handleChange}
                sx={{ gridColumn: "span 2" }}
              />
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Category Description"
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.categoryDescription || categoryDescription || ""}
                name="categoryDescription"
                error={
                  !!touched.categoryDescription && !!errors.categoryDescription
                }
                helperText={
                  touched.categoryDescription && errors.categoryDescription
                }
                sx={{ gridColumn: "span 2" }}
              />
              <FormControl sx={{ gridColumn: "span 2" }}>
                <Select
                  fullWidth
                  variant="filled"
                  name="parentId"
                  value={
                    parentIdChange ||
                    responseData.filter((option) => option.value === parentId)
                  }
                  isClearable={true}
                  onBlur={handleBlur}
                  onChange={(handleChange, handleChanges)}
                  options={responseData}
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
