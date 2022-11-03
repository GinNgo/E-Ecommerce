import { useTheme } from "@emotion/react";
import { tokens } from "../../theme";
import React, { useState, useEffect } from "react";
import Header from "../../Components/Header";

const UpdateCategory = () => {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  return <Header title="UPDATE CATEGORY" subtitle="Ceate new a Catalog" />;
};

export default UpdateCategory;
