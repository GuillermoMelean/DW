import * as z from "zod"
// import axios from "axios";
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form";
// import { toast } from "react-hot-toast";
// import { useRouter } from "next/navigation";
import { useState } from "react";

import '../styles/Home.css';
import bg from '../assets/login-bg.jpg'
import logo from '../assets/logo.png'

import { Input } from "../components/ui/input";
import { Button } from '../components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "../components/ui/dialog"
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from "../components/ui/form";

const formSchema = z.object({
  email: z.string().email(),
});

export function Home() {
  const [loading, setLoading] = useState(false);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: ""
    },
  });

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    // try {
    //   setLoading(true);
    //   const response = await axios.post('/api/weddings', values);
    //   window.location.assign(`/${response.data.id}`);
    // } catch (error) {
    //   toast.error('Something went wrong');
    // } finally {
    //   setLoading(false);
    // }
  };

  return (
    <div className="App " style={{ backgroundImage: `url(${bg})` }}>
      <header className="flex justify-center items-center w-full bg-[#38463b66]" >
        <div className="justify-center items-center row-auto">
          <div className="mt-5 row-auto">
            <div className="bg-white mx-5 border form-wrapper flowers neela-style col-md-12 rounded-lg p-12">
              <h2 className="flex justify-center section-title baseboard mb-8"><img className='w-[400px]' src={logo} /></h2>
              <p className="text-center">Junte-se a nós e comece a construir o site perfeito para tornar o seu grande dia inesquecível!</p>

              <Dialog>
                <DialogTrigger className='inline-flex items-center justify-center whitespace-nowrap rounded-md text-sm font-medium ring-offset-background transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50 bg-[#6F8374] text-primary-foreground hover:bg-[#6F8374]/90 h-10 px-4 py-2 mt-8'>Subscreva a newsletter</DialogTrigger>
                <DialogContent className="rounded-lg w-[95%]">
                  <DialogHeader className="mt-3">
                    <DialogTitle>Não perca o nosso lançamento!</DialogTitle>
                    <DialogDescription>
                      O seu e-mail está seguro connosco!
                      Não partilhamos com terceiros, apenas boas notícias diretamente para a sua caixa de entrada."
                    </DialogDescription>
                  </DialogHeader>
                  <div>
                    <div>
                      <div className="space-y-4 py-2 pb-4">
                        <div className="space-y-2">
                          <Form {...form}>
                            <form onSubmit={form.handleSubmit(onSubmit)}>
                              <FormField
                                control={form.control}
                                name="email"
                                render={({ field }) => (
                                  <FormItem>
                                    <FormLabel>E-mail</FormLabel>
                                    <FormControl>
                                      <Input disabled={loading} placeholder="Insira o seu endereço de e-mail" {...field} />
                                    </FormControl>
                                    <FormMessage />
                                  </FormItem>
                                )}
                              />
                              <div className="pt-6 space-x-2 flex items-center justify-end w-full">

                                <Button disabled={loading} type="submit">Subscrever</Button>
                              </div>
                            </form>
                          </Form>
                        </div>
                      </div>
                    </div>
                  </div>
                </DialogContent>
              </Dialog>

            </div>
          </div>
        </div>
      </header>
    </div>
  );
} 