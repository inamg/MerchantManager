import React,{useState} from 'react';
import { useRouter } from 'next/router';
import { Input } from '../components/forms/input';
import { Label } from '../components/forms/label';
import{StyledButton} from '../components/button/button';
import { useMutation } from '@apollo/react-hooks';
import {ADD_MERCHANT} from '../graphql/mutation/merchant';
import FormWrapper, {
  Row,
  Col,
  Container,
  FormTitleWrapper,
  FormTitle,
  Heading,
  SubmitBtnWrapper,
} from './add-merchant.style';

export default function addMerchant(req, res) {

  const [loading, setLoading] = useState(false);
  const [merchant, setState] = useState({
    name: '',
    description: '',
    status:'',
    url:''
  });

  const [addMerchantMutation] = useMutation(ADD_MERCHANT);

  const updateField = e => {
    setState({
      ...merchant,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = async () => {
    return await addMerchantMutation({
      variables: { merchant: merchant },
    });

    Router.push('/merchants');

  };
  
    return (
      <form>
      <FormWrapper>
        <Container>
          <FormTitleWrapper>
            <FormTitle>
            Add Merchant
            </FormTitle>
          </FormTitleWrapper>

          <Heading>
            Provide Merchant Information. Click submit when done
          </Heading>

          <Row>
            <Col xs={12} sm={6} md={6} lg={6}>
            <Label>
                Merchant's name
              </Label>
            <Input
                type='text'
                label='Merchant Name'
                name='name'
                placeholder='Enter merchant name'
                value={merchant.name}
                onChange={updateField}
                backgroundColor='#F7F7F7'
                height='48px'
              />
            </Col>

            <Col xs={12} sm={6} md={6} lg={6}>
            <Label>
                Merchant's description
              </Label>
            <Input
                type='text'
                label='Merchant description'
                name='description'
                placeholder='Enter merchant name'
                value={merchant.description}
                onChange={updateField}
                backgroundColor='#F7F7F7'
                height='48px'
              />
            </Col>

            <Col xs={12} sm={6} md={6} lg={6}>
            <Label>
                Merchant's Status
              </Label>
            <Input
                type='text'
                label='Merchant Status'
                name='status'
                placeholder='Enter merchant status(NEW, APPROVED)'
                value={merchant.status}
                onChange={updateField}
                backgroundColor='#F7F7F7'
                height='48px'
              />
            </Col>

            <Col xs={12} sm={6} md={6} lg={6}>
            <Label>
                Merchant's Url
              </Label>
            <Input
                type='text'
                label='Merchant Url'
                name='url'
                placeholder='Enter merchant url'
                value={merchant.url}
                onChange={updateField}
                backgroundColor='#F7F7F7'
                height='48px'
              />
            </Col>

          </Row>

          <Row>
          <Col xs={12} sm={6} md={6} lg={6}>
          <SubmitBtnWrapper>
            <StyledButton
              type='button'
              onClick={handleSubmit}
              size='big'
              loading={loading}
              style={{ width: '100%' }}
            >
              Submit
            </StyledButton>
          </SubmitBtnWrapper>
          </Col>
          </Row>

        </Container>
      </FormWrapper>
    </form>
        )
}