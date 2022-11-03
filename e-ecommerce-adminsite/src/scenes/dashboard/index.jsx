import { Box } from "@mui/system";
import React from "react";
import Header from "../../Components/Header";

const DashBoard = () => {
  return (
    <Box
      m="20px"
      display="flex"
      justifyContent="space-beetween"
      alignItems="center"
    >
      <Header title="DASHBOARD" subtitle="Welcom to your dashboard" />
    </Box>
  );
};

export default DashBoard;
